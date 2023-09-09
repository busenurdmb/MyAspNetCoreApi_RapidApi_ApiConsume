using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using HotelProject.WebUI.Dtos.Followers;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSocialMediaPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofile/nurbusedemirbas"),
                Headers =
    {
        { "X-RapidAPI-Key", "165cdd06e5mshb82ebf450dce236p1c3102jsn978ea6bd7f6c" },
        { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                İnstagramFollewersDto instagramFollewersDto=JsonConvert.DeserializeObject<İnstagramFollewersDto>(body);
              ViewBag.followers=instagramFollewersDto.followers;
              ViewBag.following= instagramFollewersDto.following;
                
            }


            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter32.p.rapidapi.com/getProfile?username=Microsoft"),
                Headers =
    {
        { "X-RapidAPI-Key", "165cdd06e5mshb82ebf450dce236p1c3102jsn978ea6bd7f6c" },
        { "X-RapidAPI-Host", "twitter32.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                ResultTwitterFollowersDto resultTwitterFollowersDto=JsonConvert.DeserializeObject<ResultTwitterFollowersDto>(body2);
                ViewBag.followerst = resultTwitterFollowersDto.data.user_info.followers_count;
                ViewBag.followingt = resultTwitterFollowersDto.data.user_info.friends_count;
            }


            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fbuse-nur-demirba%25C5%259F-8728321bb%2F"),
                Headers =
    {
        { "X-RapidAPI-Key", "165cdd06e5mshb82ebf450dce236p1c3102jsn978ea6bd7f6c" },
        { "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    },
            };
            using (var response3 = await client.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body3 = await response3.Content.ReadAsStringAsync();
                ResultLinkledinFollowing resultLinkledinFollowing=JsonConvert.DeserializeObject<ResultLinkledinFollowing>(body3);
                ViewBag.followerslink = resultLinkledinFollowing.data.followers_count;
              
            }
            return View();
        }
    }
}
