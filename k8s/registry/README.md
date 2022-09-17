# Docker Registry

## Tutorial

<https://www.digitalocean.com/community/tutorials/how-to-set-up-a-private-docker-registry-on-top-of-digitalocean-spaces-and-use-it-with-digitalocean-kubernetes>

``` shell
docker run --rm -ti xmartlabs/htpasswd username password >> htpasswd_file
```

``` shell
helm upgrade --install docker-registry --namespace container-registry --set replicaCount=1 --set persistence.enabled=true --set persistence.size=60Gi --set persistence.deleteEnabled=true --set persistence.storageClass=local-path --set persistence.existingClaim=docker-registry-pv-claim --set secrets.htpasswd=admin:{SHA}abFv5Y3M6RYD+f512v1lcS259WM= twuni/docker-registry --version 1.10.1
```

### Optional Node Affinity Include

``` shell
--set nodeSelector.node-type=master
```

``` shell
helm uninstall docker-registry -n container-registry
```

Release "docker-registry" does not exist. Installing it now.

NAME: docker-registry
LAST DEPLOYED: Tue Feb 22 12:25:00 2022
NAMESPACE: container-registry
STATUS: deployed
REVISION: 1
TEST SUITE: None

NOTES:
1. Get the application URL by running these commands:
  export POD_NAME=$(kubectl get pods --namespace container-registry -l "app=docker-registry,release=docker-registry" -o jsonpath="{.items[0].metadata.name}")
  echo "Visit http://127.0.0.1:8080 to use your application"
  kubectl -n container-registry port-forward $POD_NAME 8080:5000