# Reproduce
- Clone repo
- run `dotnet run .`

# Error
```
dotnet(15122,0x16c263000) malloc: *** error for object 0x600000b518c0: pointer being freed was not allocated
dotnet(15122,0x16c263000) malloc: *** set a breakpoint in malloc_error_break to debug
```

### Reproduce is not stable
The bug is not very stable;
According to my tests, about 80% of runs of this project ended in error.
In other cases, it responds with 401, as it should be.
If it doesn't reproduce, try restarting it several times.


# .NET Info
```
.NET SDK:
 Version:           8.0.101
 Commit:            6eceda187b
 Workload version:  8.0.100-manifests.69afb982

Runtime Environment:
 OS Name:     Mac OS X
 OS Version:  14.2
 OS Platform: Darwin
 RID:         osx-arm64
 Base Path:   /usr/local/share/dotnet/sdk/8.0.101/
```
