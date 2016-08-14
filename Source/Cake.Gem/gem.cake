#r "Cake.Gem.dll"

try
{
    GemBuild("./../../../../Examples/testgem/testgem.gemspec");
}
catch(Exception ex)
{
    Error("{0}", ex);
}