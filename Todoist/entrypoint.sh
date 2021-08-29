#!/bin/bash
set -e
run_cmd="dotnet run --server.urls http://*:5000"

sleep 2m

>&2 echo "SQL Server is up - executing command"
exec $run_cmd