using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlappyBirbServer.Data;
using FlappyBirbServer.Models;

namespace FlappyBirbServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly FlappyBirbServerContext _context;

        public ScoresController(FlappyBirbServerContext context)
        {
            _context = context;
        }

        // GET: api/Scores/GetPublicScores
        [HttpGet("GetPublicScores")] 
        public async Task<ActionResult<IEnumerable<Score>>> GetPublicScores()
        {
            return await _context.Score.Where(s => s.Visible).ToListAsync(); // Example for public scores
        }

        // GET: api/Scores/GetMyScores
        [HttpGet("GetMyScores")] 
        public async Task<ActionResult<IEnumerable<Score>>> GetMyScores()
        {
            
            var userId = 1; //Valeur hardcodée
            return await _context.Score.Where(s => s.ScoreOwner.Id == userId).ToListAsync(); 
        }

        // PUT: api/Scores/ChangeScoreVisibility/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeScoreVisibility(int id, Score score)
        {
            if (id != score.Id)
            {
                return BadRequest();
            }

            _context.Entry(score).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Scores/PostScore
        [HttpPost]
        public async Task<ActionResult<Score>> PostScore(Score score)
        {
            _context.Score.Add(score);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScore", new { id = score.Id }, score);
        }


        private bool ScoreExists(int id)
        {
            return _context.Score.Any(e => e.Id == id);
        }
    }
}
