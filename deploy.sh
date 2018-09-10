ApiKey=$1
Source=$2

nuget pack ./OMDbSharp/OMDbSharp.nuspec -Verbosity detailed

nuget push ./OMDbSharp.*.nupkg -Verbosity detailed -ApiKey $ApiKey -Source $Source