using MeetingRoomScheduler.Domain.Entities;
using MeetingRoomScheduler.Domain.Entities.Enums;
using MeetingRoomScheduler.Domain.Interfaces;
using MeetingRoomScheduler.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomScheduler.Infrastructure.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly ApplicationDbContext _context;

    public ReservationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Reservation?> GetReservationById(Guid id) =>
        await _context.Reservation.Include(r => r.UserId).Include(r => r.RoomId).FirstOrDefaultAsync(r => r.Id == id);

    public async Task<IEnumerable<Reservation>> GetReservationByUserId(Guid userId) =>
        await _context.Reservation.Where(r => r.UserId == userId).Include(r => r.UserId).ToListAsync();

    public async Task<IEnumerable<Reservation>> GetReservationByRoomId(Guid roomId)
    {
        return await _context.Reservation
            .Where(r => r.RoomId == roomId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Reservation>> GetReservationByDate(DateTime date) =>
        await _context.Reservation
            .Where(r => r.StartTime.Date == date.Date)
            .Include(r => r.UserId)
            .Include(r => r.RoomId)
            .ToListAsync();

    public async Task<IEnumerable<Reservation>> GetReservationsByFilters(DateTime? date, ReservationStatus? status)
    {
        var query = _context.Reservation.AsQueryable();

        if (date.HasValue)       
            query = query.Where(r => r.StartTime.Date == date.Value.Date);
        

        if (status.HasValue)       
            query = query.Where(r => r.Status == status.Value);
        
        return await query.ToListAsync();
    }

    public async Task AddReservation(Reservation reservation)
    {
        await _context.Reservation.AddAsync(reservation);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateReservation(Reservation reservation)
    {
        _context.Reservation.Update(reservation);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteReservation(Guid id)
    {
        var reservation = await _context.Reservation.FindAsync(id);
        if (reservation != null)
        {
            _context.Reservation.Remove(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
