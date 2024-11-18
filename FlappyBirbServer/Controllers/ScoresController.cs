using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlappyBirbServer.Data;
using FlappyBirbServer.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using FlappyBirbServer.Services;

namespace FlappyBirbServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private readonly FlappyBirbServerContext _context;
        private readonly ScoreService _scoreService;

        public ScoresController(FlappyBirbServerContext context, ScoreService scoreService)
        {
            _context = context;
            _scoreService = scoreService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> GetPublicScores()
        {
            var scores = await _context.Score
                .Where(s => s.IsPublic)
                .OrderByDescending(a => a.ScoreValue)
                .Select(s => new {
                    s.Pseudo,
                    s.ScoreValue,
                    ScoreInSeconds = s.TimeInSeconds,
                    s.Date
                })
                .ToListAsync();

            return Ok(scores);
        }


        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Score>>> GetMyScores()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var scores = await _context.Score.Where(s => s.UserId == userId).OrderByDescending(a => a.ScoreValue).ToListAsync();
            return Ok(scores);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Score>> ChangeScoreVisibility(int id, [FromBody] bool Visible)
        {
            var score = await _scoreService.ChangeScoreVisibility(id, Visible);
            if (!score)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Score>> PostScore([FromBody] Score score)
        {
            score.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            score.Date = DateTime.Now.ToString("yyyy-MM-dd");
            var newScore = await _scoreService.AddNewScore(score);
            if (newScore == null)
            {
                return BadRequest("Impossible d'ajouter le score");
            }
            score.ScoreOwner = await _context.Users.FindAsync(score.UserId);
            return CreatedAtAction(nameof(GetMyScores), new { id = newScore.Id }, newScore);
        }
    }
}
