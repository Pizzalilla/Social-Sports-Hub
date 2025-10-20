# 🏀 **Social Sports Hub**

**Social Sports Hub** is a cross-platform mobile app built with **.NET MAUI** that makes it easy to host, discover, and join local pickup sports games.  
Whether you’re looking for a quick soccer match, basketball run, or simply want to connect with nearby players — Social Sports Hub helps you find and create games in minutes.

---

## ⚙️ **Project Setup**

### 🧩 **Step 1 — Add the Existing Data Project**
1. Open the **`Social_Sport_Hub.sln`** solution in **Visual Studio**.  
2. In **Solution Explorer**, right-click the solution → **Add → Existing Project...**  
3. Navigate to the `Social_Sport_Hub.Data` folder and select the file:  

4. Ensure the project now appears under the solution along with the main app project.

---

### 🔗 **Step 2 — Add a Project Reference**
To allow the main MAUI project to access the data layer components:

1. In **Solution Explorer**, right-click the **Social_Sport_Hub** project → **Add → Project Reference...**  
2. Check the box next to **Social_Sport_Hub.Data** and click **OK**.  
3. If it still doesn’t load, manually edit the `.csproj` file and include the full path:
```xml
<ItemGroup>
  <ProjectReference Include="C:\FullPath\To\Social_Sport_Hub.Data\Social_Sport_Hub.Data.csproj" />
</ItemGroup>
```xml
