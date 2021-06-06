import { Environment, Network, RecordSource, Store } from "relay-runtime";
// import {
//   RelayNetworkLayer,
//   urlMiddleware,
//   batchMiddleware,
//   // legacyBatchMiddleware,
//   loggerMiddleware,
//   errorMiddleware,
//   perfMiddleware,
//   retryMiddleware,
//   authMiddleware,
//   cacheMiddleware,
//   progressMiddleware,
//   uploadMiddleware,
// } from "react-relay-network-modern";
//
// const source = new RecordSource();
// const store = new Store(source);
//
// const network = new RelayNetworkLayer([
//   authMiddleware({
//     token: () => store.get("jwt"),
//   }),
// ]);

async function fetchRelay(params: any, variables: any, _cacheConfig: any) {
  const getToken = () => {
    const token = localStorage.getItem("authToken");

    if (!token) {
      return "";
    }

    return token;
  };

  const response = await fetch("https://localhost:5100/graphql", {
    method: "POST",
    headers: {
      "Accept": "application/json",
      "Content-Type": "application/json",
      "authorization": getToken(),
    },
    body: JSON.stringify({
      query: params.text,
      variables,
    }),
  });

  // Get the response as JSON
  const json = await response.json();

  // GraphQL returns exceptions (for example, a missing required variable) in the "errors"
  // property of the response. If any exceptions occurred when processing the request,
  // throw an error to indicate to the developer what went wrong.
  if (Array.isArray(json.errors)) {
    console.log(json.errors);
    throw new Error(
      `Error fetching GraphQL query '${
        params.name
      }' with variables '${JSON.stringify(variables)}': ${JSON.stringify(
        json.errors
      )}`
    );
  }

  // Otherwise, return the full payload.
  return json;
}

// Export a singleton instance of Relay Environment configured with our network layer:
export default new Environment({
  network: Network.create(fetchRelay),
  store: new Store(new RecordSource(), {
    // This property tells Relay to not immediately clear its cache when the user
    // navigates around the app. Relay will hold onto the specified number of
    // query results, allowing the user to return to recently visited pages
    // and reusing cached data if its available/fresh.
    gcReleaseBufferSize: 10,
  }),
});
