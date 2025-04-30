using IdentityServer4.Models;

namespace LocadoraDeCarro.IdentityServer;

public static class Config
{
	public static IEnumerable<IdentityResource> IdentityResources =>
			new IdentityResource[]
			{
						new IdentityResources.OpenId(),
						new IdentityResources.Profile()
			};

	public static IEnumerable<ApiScope> ApiScopes => new[]
	{
				new ApiScope("locadora_api", "Locadora API")
		};

	public static IEnumerable<ApiResource> ApiResources => new[]
	{
				new ApiResource("locadora_api", "Locadora API")
				{
						Scopes = { "locadora_api" }
				}
		};

	public static IEnumerable<Client> Clients => new[]
	{
				new Client
				{
						ClientId = "locadora_client",
						AllowedGrantTypes = GrantTypes.ClientCredentials,
						ClientSecrets = { new Secret("super_senha".Sha256()) },
						AllowedScopes = { "locadora_api" }
				}
		};
}


