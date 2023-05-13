using Azure.Core;
using LocalFootballTeam.Migrations;
using LocalFootballTeam.Models.Models;
using LocalFootballTeam.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace LocalFootballTeam.Services.Services
{
    public class TeamService : ITeamService
    {

        private readonly Migrations.DbContext _context;
        
        public TeamService(Migrations.DbContext context)
        {
            _context = context;
        }

        #region GetAllTeams
        public async Task<List<Team>> GetAllTeams()
        {
            return await _context.Teams.ToListAsync();
        }
        #endregion

        #region GetTeam
        public async Task<Team> GetTeam(int id)
        {
            var result = await _context.Teams.FindAsync(id);

            if (result == null)
                return null;

            return result;
        }
        #endregion

        #region AddTeam
        public async Task<List<Team>> AddTeam(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return await _context.Teams.ToListAsync();
        }
        #endregion

        #region UpdateTeam
        public async Task<List<Team>> UpdateTeam(Team team, int id)
        {
            var result = await _context.Teams.FindAsync(id);

            if (result == null)
                return null;

            result.Name = team.Name;
            result.Addres = team.Addres;
            result.StartYear = team.StartYear;
            result.Logo = team.Logo;

            await _context.SaveChangesAsync();

            return await _context.Teams.ToListAsync();
        }
        #endregion

        #region DeleteTeam
        public async Task<List<Team>> DeleteTeam(int id)
        {
            var result = await _context.Teams.FindAsync(id);

            if (result == null)
                return null;

            _context.Teams.Remove(result);
            await _context.SaveChangesAsync();


            return await _context.Teams.ToListAsync(); 
        }
        #endregion

        
    }
}
