#!/bin/bash
openssl genrsa 2048 > server.key
openssl req -new -sha256 -key server.key -out server.csr -subj "/CN=localhost"
openssl x509 -req -in server.csr -signkey server.key -out server.crt -days 365 -extensions server
openssl x509 -in server.crt -text -out server.humanreadable.crt

# Place certificate file to Server
cp server.crt MinimalTLSServer/MinimalTLSServer
cp server.key MinimalTLSServer/MinimalTLSServer

# Place certificate file to Client
cp server.crt MinimalTLSServer/TestClient
