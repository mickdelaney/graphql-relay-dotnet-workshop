set htaccess=admin:$apr1$l1x356rh$YWc5b4eKs0y6r45ziSaqb0
set user=admin
set password=@lincregistry10

docker run --rm -ti xmartlabs/htpasswd admin @lincregistry10 >> htpasswd_file

kubectl create namespace container-registry
kubectl apply -f pv.yaml

helm repo add twuni https://helm.twun.io
helm repo update 
helm upgrade --install docker-registry --namespace container-registry --set replicaCount=1 --set persistence.enabled=true --set persistence.size=60Gi --set persistence.deleteEnabled=true --set persistence.storageClass=local-path --set persistence.existingClaim=docker-registry-pv-claim --set secrets.htpasswd=admin:$2y$05$PDw6aUYq/aaTGjKOJfryg.HWMIq7rmKY2jfC/udQbWrT.pnq7oqiq twuni/docker-registry --version 1.10.1

kubectl apply -f ingress-route.yaml -n container-registry

https://registry.local.hirelinc.com/v2/_catalog

helm uninstall docker-registry --namespace container-registry