    <profile defaultProvider="AspNetSqlProfileProvider">
         <providers>
               <clear />
               <add name="AspNetSqlProfileProvider" type="System.Web.Profile.SqlProfileProvider, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" connectionStringName="LocalSqlServer" applicationName="/" />
         </providers>
    </profile>
