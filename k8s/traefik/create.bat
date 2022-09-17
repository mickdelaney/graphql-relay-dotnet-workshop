kubectl -n kube-system get pods --selector "app.kubernetes.io/name=traefik" --output=name

kubectl port-forward -n kube-system pod/traefik-55fdc6d984-q922t 9000:9000


https://127.0.0.1:9000/dashboard/#/http/routers/container-registry-docker-registry-3028b9790ef4d9593e3b@kubernetescrd


https://localhost:9000/dashboard/#/http/routers/container-registry-docker-registry-3028b9790ef4d9593e3b@kubernetescrd