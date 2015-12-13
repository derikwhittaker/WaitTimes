function init(app, io) {
    
    var moment = require("moment");
    var disneyAPI = new (require("wdwjs"))({
        timeFormat: "HH:mm"
    });    
    
       
    function GetWaitTimes(httpResult, disneyApi, disneyApiName){
        console.info("Fetching wait times for " + disneyApiName + " at " + moment().format('L, h:mm:ss a') );
        
        disneyApi.GetWaitTimes(function(err, data) {
            if (err) return console.error("Error fetching " + disneyApiName + " wait times: " + err);
            if( data === null ){ return console.error(disneyApiName + " result was null"); }
                     
            httpResult.send(JSON.stringify(data, null, 2));
        });         
    };
    
    // Florida
    app.get('/api/animalKingdom', function (req, res) {
        var disneyApi = disneyAPI.AnimalKingdom;
        GetWaitTimes(res, disneyApi, "Animal Kingdom");        
    });
    
    app.get('/api/epcot', function (req, res) {
        var disneyApi = disneyAPI.Epcot;
        GetWaitTimes(res, disneyApi, "Epcot");        
    });   
    
    app.get('/api/hollywoodStudios', function (req, res) {
        var disneyApi = disneyAPI.HollywoodStudios;
        GetWaitTimes(res, disneyApi, "Hollywood Studios");        
    });      
    
    app.get('/api/magicKingdom', function (req, res) {
        var disneyApi = disneyAPI.MagicKingdom;
        GetWaitTimes(res, disneyApi, "Magic Kingdom");        
    });     
    
     // California
    app.get('/api/californiaAdventure', function (req, res) {
        var disneyApi = disneyAPI.CaliforniaAdventure;
        GetWaitTimes(res, disneyApi, "California Adventure");        
    });

    app.get('/api/disneyLand', function (req, res) {
        var disneyApi = disneyAPI.Disneyland;
        GetWaitTimes(res, disneyApi, "Disney Land");        
    });
    
     // Paris
    app.get('/api/disneylandParis', function (req, res) {
        var disneyApi = disneyAPI.DisneylandParis;
        GetWaitTimes(res, disneyApi, "Disneyland Paris");        
    }); 
    
    app.get('/api/waltDisneyStudios', function (req, res) {
        var disneyApi = disneyAPI.WaltDisneyStudios;
        GetWaitTimes(res, disneyApi, "Walt Disney Studios");        
    });        
       
}


module.exports = init;
