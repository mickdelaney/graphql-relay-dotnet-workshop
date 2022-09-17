kubectl create namespace cert-manager
kubectl label namespace cert-manager certmanager.k8s.io/disable-validation=true

helm repo add jetstack https://charts.jetstack.io
helm repo update
helm search repo cert-manager

helm upgrade --install cert-manager --namespace cert-manager --version v1.7.1 jetstack/cert-manager --set installCRDs=true

kubectl apply -f cluster-issuer.yaml -n linc

kubectl get clusterissuers local.hirelinc.com-ca-issuer -o wide

kubectl apply -f linc-local-certificate.yaml -n linc

kubectl describe certificate linc-local-com-cert --namespace linc

kubectl get secret --namespace linc

kubectl get secret linc-local-cert-secret -o yaml --namespace linc

:: cert_file - client certificate path used for authentication

kubectl get secret linc-local-cert-secret --namespace linc -o jsonpath='{.data.tls\.crt}' | base64 -d > cert-secrets/cert_file.crt

:: key_file - client key path used for authentication

kubectl get secret linc-local-cert-secret --namespace linc -o jsonpath='{.data.tls\.key}' | base64 -d > cert-secrets/key_file.key

:: ca_file - CA certificate path used to verify the remote server cert file

kubectl get secret linc-local-cert-secret --namespace linc -o jsonpath='{.data.ca\.crt}' | base64 -d > cert-secrets/ca_file.crt