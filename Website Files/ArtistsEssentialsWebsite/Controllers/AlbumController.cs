using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using ArtistsEssentialsWebsite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArtistsEssentialsWebsite.Controllers
{
    public class AlbumController : Controller
    {

        readonly HttpClient client = new();

        // GET: Album
        public ActionResult Index()
        {
            return View();
        }


        public async Task<ActionResult> ShowAlbums(string genre)
        {
            //  Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                );

            //  Json File for openweathermap.ord is all lowercase
            //  We assign case insesitivity to handle lower case names
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var response = client.GetStringAsync("http://localhost:8080/api/EssentialAlbums?genre="+genre);

            List<Album> artists = new();
            try
            {
                var msg = await response;
                //Console.WriteLine(msg);
                artists = JsonSerializer.Deserialize<List<Album>>(msg, options);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Artist");
            }

            return View(artists);
        }

        // GET: Album/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Album/Create?artistId
        public ActionResult Create(long artistId)
        {
            return View();
        }

        // POST: Album/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Album @album)
        {
            try
            {
                var response = await client.PostAsJsonAsync("http://localhost:8080/api/EssentialAlbums", @album);
                return RedirectToAction("Details", "Artist", new { id = @album.EssentialArtistId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Album/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            //  Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                );

            //  Json File for openweathermap.ord is all lowercase
            //  We assign case insesitivity to handle lower case names
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var response = client.GetStringAsync("http://localhost:8080/api/EssentialAlbums/" + id);

            Album album = new();

            try
            {
                var msg = await response;

                album = JsonSerializer.Deserialize<Album>(msg, options);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(album);
        }

        // POST: Album/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Album @album)
        {
            try
            {
                var url = "http://localhost:8080/api/EssentialAlbums/" + id;

                var response = await client.PutAsJsonAsync(url, @album);

                return RedirectToAction("Details", "Artist", new { id = @album.EssentialArtistId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Album/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Album/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Album @album)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [BindProperty]
        public long EssentialArtistId { get; set; }

        [BindProperty]
        public string Title { get; set; }
        [BindProperty]
        public string Genre { get; set; }
        [BindProperty]
        public int ReleaseYear { get; set; }
        [BindProperty]
        public string CreatedBy { get; set; }
        [BindProperty]
        public string CoverImage { get; set; }
        [BindProperty]
        public int? BillboardPeakUS { get; set; }
        [BindProperty]
        public int? WeeksOnChartUS { get; set; }
        [BindProperty]
        public string Certification { get; set; }
        [BindProperty]
        public decimal? PitchforkRating { get; set; }
        [BindProperty]
        public decimal? MetacriticRating { get; set; }
        [BindProperty]
        public decimal? RollingStoneRating { get; set; }
        [BindProperty]
        public decimal? RateYourMusicRating { get; set; }
        [BindProperty]
        public int? GrammyNominations { get; set; }
        [BindProperty]
        public int? GrammyWins { get; set; }
    }
}