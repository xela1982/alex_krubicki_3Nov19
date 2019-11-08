# alex_krubicki_3Nov19

Basic implementation of layers separation by separation of concern.

1) Run script that was attached to my eamil to create and seed DB ( update connection string ) 
2) Call api/TakeAway/GetCompanies to GET all companies 
3) Call api/TakeAway/GetReportByParam and pass companyId,startDate,endDate to GET report for employees card holders. 
4) Implemented Repository as a class library so it can be shared across different projects e.g mobile \ web \ api
5) Implemented Repository to allow switch between ADO and EF 
6) Script file was added for creating and seeding DB. 

Created a DB and App application in Azure, the supported URLs are
http://alexkrubicki3nov19.azurewebsites.net/
http://alexkrubicki3nov19.azurewebsites.net/GetReportByParam?companyid=1&startdate=2010-10-1&enddate=2010-10-29



I  run this soltuion on Microsoft Visual Studio Community 2017 
Version 15.9.17 just to confirm backward compatibility.
