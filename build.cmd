@echo off
echo "Restoring tools..."
dotnet tool restore
echo "Start building..."
dotnet cake build/build.cake
echo "Complete!"
