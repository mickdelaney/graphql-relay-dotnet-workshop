helm install docker-registry-ui --namespace container-registry . -f values.yaml 

kubectl apply -f ingress-route.yaml -n container-registry

https://docker-registry-ui.local.rivul.io

helm uninstall docker-registry-ui --namespace container-registry