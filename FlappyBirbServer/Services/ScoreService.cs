using FlappyBirbServer.Data;
using FlappyBirbServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlappyBirbServer.Services
{
    public class ScoreService
    {
        private readonly FlappyBirbServerContext _context;
        public ScoreService(FlappyBirbServerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Score>> GetMyScores(string userId)
        {
            return await _context.Score.Where(s => s.ScoreOwner != null && s.ScoreOwner.Id == userId).ToListAsync();
        }


        public async Task<bool> ChangeScoreVisibility(int id, bool visibility)
        {
            var score = await _context.Score.FindAsync(id);
            if (score == null)
            {
                return false;
            }

            score.IsPublic = visibility;
            _context.Entry(score).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoreExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        // Ca rend ca plus simple
        public async Task<Score> AddNewScore(Score score)
        {
            _context.Score.Add(score);
            await _context.SaveChangesAsync();
            return score;
        }

        private bool ScoreExists(int id)
        {
            return _context.Score.Any(e => e.Id == id);
        }
    }
}
