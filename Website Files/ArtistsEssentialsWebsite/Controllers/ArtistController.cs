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
using Microsoft.VisualBasic;

namespace ArtistsEssentialsWebsite.Controllers
{
    public class ArtistController : Controller
    {
        readonly HttpClient client = new();

        // GET: Artist
        public ActionResult Index()
        {
            List<string> genres = new() { "pop", "hip hop", "soul", "rock", "electronic", "country", "metal", "punk" , "jazz" };
            return View(genres);
        }


        public async Task<ActionResult> ShowArtists(string genre)
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

            var response = client.GetStringAsync("http://localhost:8080/api/EssentialArtists?genre="+genre);

            List<Artist> artists = new();
            try
            {
                var msg = await response;
                //Console.WriteLine(msg);
                artists = JsonSerializer.Deserialize<List<Artist>>(msg, options);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(artists);
        }

        // GET: Artist/Details/5
        public async Task<ActionResult> Details(int id, string sortby = "critics")
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

            var response = client.GetStringAsync("http://localhost:8080/api/EssentialArtists/" + id);

            List<Album> albums = new();
            try
            {
                var msg = await response;

                var artist = JsonSerializer.Deserialize<Artist>(msg, options);

                ViewData["artistName"] = artist.Name;
                ViewData["artistID"] = artist.Id;
                ViewData["artistGenre"] = artist.Genre;
                albums = artist.EssentialAlbums;
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }


            if (sortby == "critics")
            {
                ViewData["isChecked_co"] = "";
                ViewData["isChecked_aw"] = "";
                ViewData["isChecked_on"] = "";
                ViewData["isChecked_cr"] = "checked";
                return View(albums.OrderByDescending(a => a.PitchforkRating).ThenByDescending(a => a.RollingStoneRating));
            }
            else if (sortby == "online")
            {
                ViewData["isChecked_co"] = "";
                ViewData["isChecked_aw"] = "";
                ViewData["isChecked_cr"] = "";
                ViewData["isChecked_on"] = "checked";
                return View(albums.OrderByDescending(a => a.RateYourMusicRating).ThenByDescending(a => a. MetacriticRating));
            }
            else if (sortby == "commercial")
            {
                ViewData["isChecked_aw"] = "";
                ViewData["isChecked_cr"] = "";
                ViewData["isChecked_on"] = "";
                ViewData["isChecked_co"] = "checked";
                return View(albums.OrderBy(a => a.BillboardPeakUS).ThenByDescending(a => a.WeeksOnChartUS));
            }
            else if (sortby == "awards")
            {
                ViewData["isChecked_cr"] = "";
                ViewData["isChecked_co"] = "";
                ViewData["isChecked_on"] = "";
                ViewData["isChecked_aw"] = "checked";
                return View(albums.OrderByDescending(a => a.GrammyWins).ThenByDescending(a => a.GrammyNominations));
            }

            return View(albums);
        }

        // GET: Artist/Create
        public ActionResult Create(string genre)
        {
            return View();
        }

        // POST: Artist/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Name,Genre,Image")] Artist @artist)
        {
            try
            {
                var response = await client.PostAsJsonAsync("http://localhost:8080/api/EssentialArtists", @artist);

                
                //Console.WriteLine(response.EnsureSuccessStatusCode());

                return RedirectToAction("ShowArtists", new { @artist.Genre });
            }
            catch
            {
                return View();
            }
        }

        // GET: Artist/Edit/5
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

            var response = client.GetStringAsync("http://localhost:8080/api/EssentialArtists/" + id);

            Artist artist = new();

            try
            {
                var msg = await response;

                artist = JsonSerializer.Deserialize<Artist>(msg, options);      
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(artist);
        }

        // PuT: Artist/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("Id,Name,Genre,Image")] Artist @artist)
        {
            try
            {
                var url = "http://localhost:8080/api/EssentialArtists/" + id;

                var response = await client.PutAsJsonAsync(url, @artist);

                return RedirectToAction("ShowArtists", new { @artist.Genre });
            }
            catch
            {
                return View();
            }
        }

        // GET: Artist/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Artist/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}