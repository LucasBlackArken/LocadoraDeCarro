using IdentityServer4.Models;
using IdentityServer4.Test;

namespace LocadoraDeCarro.IdentityServer;

public static class Config
{
	public static IEnumerable<IdentityResource> IdentityResources =>
			new IdentityResource[]
			{
						new IdentityResources.OpenId(),
						new IdentityResources.Profile()
			};

	public static IEnumerable<ApiScope> ApiScopes =>
			new ApiScope[]
			{
						new ApiScope("locadora_api", "Locadora de Carros API")
			};

	public static IEnumerable<Client> Clients =>
			new Client[]
			{
						new Client
						{
								ClientId = "locadora_client",
								AllowedGrantTypes = GrantTypes.ClientCredentials,
								ClientSecrets =
								{
										new Secret("super_senha".Sha256())
								},
								AllowedScopes = { "locadora_api" }
						}
			};

	public static List<TestUser> Users =>
			new List<TestUser>
			{
						new TestUser
						{
								SubjectId = "1",
								Username = "usuario1",
								Password = "senha123"
						}
			};
}

