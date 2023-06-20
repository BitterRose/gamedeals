using GameDeals.Application.Genre.Interfaces;
using GameDeals.Application.Genre.Models;
using GameDeals.Domain.Repositories;

namespace GameDeals.Application.Genre.Services;
public class GenreService : IGenreService
{
	private readonly IGenreRepository _genreRepository;
	public GenreService(IGenreRepository genreRepository)
	{
		_genreRepository = genreRepository;
	}

	public async Task DeleteGenreAsync(Guid id)
	{
		await _genreRepository.DeleteAsync(id);
	}

	public async Task CreateGenreAsync(GenreDto genre)
	{
		await _genreRepository.CreateAsync(new Domain.Entities.Genre.Genre(genre.Name));
	}

	public async Task<GenreDto> GetGenreAsync(Guid id)
	{
		var genreDto = await _genreRepository.GetAsync(id);
		return new GenreDto(genreDto.Id, genreDto.Name);
	}

	public async Task<IEnumerable<GenreDto>> GetGenresAsync()
	{
		var genres = await _genreRepository.GetAllAsync();
		var genreDtos = new List<GenreDto>();
		foreach (var genre in genres)
		{
			genreDtos.Add(new GenreDto(genre.Id, genre.Name));
		}
		return genreDtos;
	}

	public async Task UpdateGenreAsync(Guid id, GenreDto genre)
	{
		await _genreRepository.UpdateAsync(new Domain.Entities.Genre.Genre(id, genre.Name));
	}
}
