htaccess=admin:$2y$05$PsV/k7vrhhfiH5dFyBVTWe/HoiHPR5Jxmy5H6v9fIHh9jSkVSbAbq
user=admin
password=@lincregistry10

docker run --rm -ti xmartlabs/htpasswd admin @lincregistry10 >> htpasswd_file

kubectl create namespace container-registry
kubectl apply -f pv.yaml

helm repo add twuni https://helm.twun.io
helm repo update 

helm install docker-registry --namespace container-registry twuni/docker-registry -f registry.values.yaml 
--version 2.1.0

helm upgrade --install docker-registry \
--namespace container-registry \
--set replicaCount=1 \
--set persistence.enabled=true \
--set persistence.size=60Gi \
--set persistence.deleteEnabled=true \
--set persistence.storageClass=local-path \
--set persistence.existingClaim=docker-registry-pv-claim \
--set secrets.htpasswd=$htaccess \
--set ingress.enabled=true \
--set ingress.path=docker-registry \
--set ingress.hosts=local.hirelinc.com \
twuni/docker-registry \
--version 2.1.0

kubectl apply -f ingress-route.yaml -n container-registry

https://local.hirelinc.com/docker-registry/v2/_catalog

helm uninstall docker-registry --namespace container-registry