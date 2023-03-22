import { dotnet } from './dotnet.js';

const config = getConfig();
const exports = await getAssemblyExports(config.mainAssemblyName);

const url = exports.StoreUtility.GetProductUrl(); 
console.log(url);

await JSHost.ImportAsync("view.js", "./view.js");      
