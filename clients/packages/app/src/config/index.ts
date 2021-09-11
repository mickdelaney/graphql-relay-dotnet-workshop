export default {
  response_type: 'code',
  scope: 'openid profile accounts.api content.api',
  clientId: 'graphql.client',
  authority: 'https://localhost:5703',
  redirectUri: 'http://localhost:5704/signin-oidc',
};
