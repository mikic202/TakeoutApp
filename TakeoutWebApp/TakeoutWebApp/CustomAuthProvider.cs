using Blazored.LocalStorage;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Components.Authorization;
using Signin;
using System.Security.Claims;

namespace TakeoutWebApp
{
	public class CustomAuthProvider : AuthenticationStateProvider
	{
		private readonly ILocalStorageService _localStoarage;

		public CustomAuthProvider(ILocalStorageService localStoarage) {
			this._localStoarage=localStoarage;
		}
		
		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			var state = new AuthenticationState(new System.Security.Claims.ClaimsPrincipal());

            string username = await _localStoarage.GetItemAsStringAsync("username");
			if (!string.IsNullOrEmpty(username))
			{
				var identity = new ClaimsIdentity(new[]
				{
					new Claim(ClaimTypes.Name, username)
				}, "test authentication type");

				state = new AuthenticationState(new System.Security.Claims.ClaimsPrincipal(identity));
			}
			NotifyAuthenticationStateChanged(Task.FromResult(state));
			return state;
		}
	}
}
