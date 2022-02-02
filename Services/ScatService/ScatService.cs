using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scat_chat_api.Models;
using scat_chat_api.Dtos.Scat;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using scat_chat_api.Data;
using Microsoft.EntityFrameworkCore;

namespace scat_chat_api.Services.ScatService
{
	public class ScatService : IScatService
	{

		private readonly DataContext _context;

		private readonly IMapper _mapper;
		public ScatService(IMapper mapper, DataContext context)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<ServiceResponse<List<GetScatDto>>> AddScat(AddScatDto newScat)
		{
			var serviceResponse = new ServiceResponse<List<GetScatDto>>();
			Scat scat = _mapper.Map<Scat>(newScat);
			_context.Scats.Add(scat);
			await _context.SaveChangesAsync(); //will update Id with this call to database
			serviceResponse.Data = await _context.Scats.Select(s => _mapper.Map<GetScatDto>(s)).ToListAsync();
			return serviceResponse; 
		}

		public async Task<ServiceResponse<List<GetScatDto>>> DeleteScat(int id)
		{
			var serviceResponse = new ServiceResponse<List<GetScatDto>>();

			try
			{
				Scat scat = await _context.Scats.FirstAsync(s => s.Id == id);
				_context.Scats.Remove(scat);
				await _context.SaveChangesAsync();
				serviceResponse.Data = null;
			}
			catch (Exception e)
			{
				serviceResponse.Success = false;
				serviceResponse.Message = "No document found with that id.";
				serviceResponse.Data = _context.Scats.Select(c => _mapper.Map<GetScatDto>(c)).ToList();
			}

			return serviceResponse;
		}

		public async Task<ServiceResponse<List<GetScatDto>>> GetAllScats()
		{
			var serviceResponse = new ServiceResponse<List<GetScatDto>>();
			var dbScats = await _context.Scats.ToListAsync();
			serviceResponse.Data = dbScats.Select(s => _mapper.Map<GetScatDto>(s)).ToList();
			return serviceResponse;
		}

		public async Task<ServiceResponse<GetScatDto>> GetScatById(int id)
		{
			var serviceResponse = new ServiceResponse<GetScatDto>();
			var dbScat = await _context.Scats.FirstOrDefaultAsync(scat => scat.Id == id);
			serviceResponse.Data = _mapper.Map<GetScatDto>(dbScat);
			return serviceResponse;
		}

		public async Task<ServiceResponse<GetScatDto>> UpdateScat(UpdateScatDto updatedScat)
		{
			var serviceResponse = new ServiceResponse<GetScatDto>();

			try
			{
				Scat scat = await _context.Scats.FirstOrDefaultAsync(s => s.Id == updatedScat.Id);
				scat.Text = updatedScat.Text;
				scat.Author = updatedScat.Author;
				scat.Color = updatedScat.Color;

				await _context.SaveChangesAsync();

				serviceResponse.Data = _mapper.Map<GetScatDto>(scat);
			}
			catch (Exception e)
			{
				serviceResponse.Success = false;
				serviceResponse.Message = e.Message;
			}
			return serviceResponse;
		}
	}
}