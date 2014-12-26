<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPPatterns.Chap9.PeriodicRefresh.UI.Web._Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript" src="/Scripts/jquery-1.3.2.js"></script> 
    <link href="/Content/Site.css" type="text/css" rel="stylesheet" /> 
    <script type="text/javascript">

        var pollforupdates = true;
        var mostRecentEvent = 0;
        var timer;

        $(document).ready(function() {
            // Periodic Refresh Pattern Implementation
            // when the document has fully loaded start the polling for data
            getLastestEvents();

            // Timeout Pattern Implementation
            // set up a timer to monitor user inactivity
            setupTimerToCheckForInactivity();
            // hook up event handlers to actions that prove the user is still using 
            // the page
            hookUpEventHandlersToDetermineActivity();

        });

        function getLastestEvents() {

            // this method performs an asynchronous POST to 
            // retrieve any new events since the last event was displayed
            dto = { 'eventId': mostRecentEvent };
            varType = "POST";
            varUrl = "LiveScoreSummary.asmx/GetEventsThatHaveOccuredSince";
            varContentType = "application/json; charset=utf-8";
            varDataType = "json";
            varData = JSON.stringify(dto);

            $.ajaxSetup({ cache: false });

            $.ajax({
                type: varType, // GET or POST or PUT or DELETE verb
                url: varUrl, // location of the service
                data: varData, // data sent to server
                contentType: varContentType, // content type sent to server
                dataType: varDataType, // expected data format from server
                success: serviceSuccessful, // on successfull service call 
                                             // the serviceSuccessful method
                error: serviceFailed // on unsuccessfull service call 
                                     // the serviceFailed method
            });
        }

        function setupTimerToCheckForInactivity() {

            // this method sets up a timer to pause the
            // polling of events after a given time
            // in this example a user is inactive if they haven't
            // interacted with the screen for more than 5 seconds 
            timer = setTimeout(
                function() {
                    pauseUpdates()
                }, 5000);
        }

        function hookUpEventHandlersToDetermineActivity() {

            // this method will set up event handlers that will
            // reset the inactivity timer
            
            // this hooks into the mouse move event
            $(document).mousemove(function(event) {
                resetInactivityTimeCounter();
            });

            // this hooks into the window focus event
            $(window).bind("focus", function() {
                resetInactivityTimeCounter();
            });        
        }
            
        function pauseUpdates() {
            pollforupdates = false;
        }
                
        function displayPauseMessage() {
            $("#Paused").slideDown("slow");
        }

        function resetInactivityTimeCounter() {

            // If the viewer had timedout then the 
            // polling for events needs to resume
            if (pollforupdates == false) {
                pollforupdates = true;
                getLastestEvents();
            }
                                                
            $("#Paused").hide();
            // stop the timer
            clearTimeout(timer);
            // restart the time
            setupTimerToCheckForInactivity()                        
        }
                       
        function serviceFailed(result) {
            alert('Service call failed: ' + result.status + '' + result.statusText);
        }

        function serviceSuccessful(resultObject) {
            // on a successful ajax POST the JSON array result
            // is passed to the displayEvents method
            displayEvents(resultObject.d, 0);
        }

        function displayEvents(events, indexOfEventToAdd) {
                    
            if (events.length > indexOfEventToAdd)
            {
                var event = events[indexOfEventToAdd];
                var eventId = "#Event_" + event.Id;

                if (eventDoesNotExistOnPage(eventId)) {

                    // update most recent event
                    mostRecentEvent = event.Id

                    addEventDivAndShowLoadingDiv(event, eventId);

                    // wait 2 seconds and then hide the loading divs 
                    // and show the event
                    setTimeout(function() {
                       
                        hideLoadingDivAndShowEventDiv(eventId);
                       
                        // wait 2 seconds and then display the next event returned from the
                        // call to the service recursively calling this function
                        setTimeout(function() {
                            displayEvents(events, indexOfEventToAdd + 1)
                        }, 2000);

                    }, 2000);
                }
                else {
                    // the event already exists on the page so
                    // check the next event by recursively calling this function
                    displayEvents(events, indexOfEventToAdd + 1)
                }
           }
           else {

               // check to see if we should call the ajax method
               // i.e. if the user is still active
               if (pollforupdates == true) {
                   pauseThenCheckForNewEvents()
               }
               else                   
                   displayPauseMessage();
           }
       }

       function hideLoadingDivAndShowEventDiv(eventId) {
           $("#LoadingBlock").hide();
           $(eventId).show();
           $("#Loading").fadeOut('slow');
       }

       function addEventDivAndShowLoadingDiv(event, eventId) {
                     
           // prepend the new event to the Event div
           $("#Event").prepend("<div id='Event_" + event.Id + "' class='EventItem'><b>" + 
                               event.Time + " :</b> " + event.Text + "<br/><br/></div>");

           // get the position of the new event div
           var pos = $(eventId).offset();
           var width = $("#Event").width();
           var height = $(eventId).height();

           // hide the new event div as we want to show a loading 
           // screen to alert the user of a new event
           $(eventId).hide();

           // show the waiting loading div directly over the newly added event
           $("#Loading").css({ "width": width + "px",
                               "left": pos.left + "px",
                               "top": pos.top + "px", 
                               "height": height + "px" });
           $("#LoadingBlock").css({ "height": height + "px" });
           $("#Loading").slideDown("slow");
           $("#LoadingBlock").slideDown("slow");
       }

       function pauseThenCheckForNewEvents() {
           // wait 3 seconds then call the ajax method to 
           // retirve new events
           setTimeout(
                        function() {
                            getLastestEvents()
                        }, 3000);
       }
       
       function eventDoesNotExistOnPage(eventId) {
          // this checks to see if there is a div
          // for the given event
          return ($(eventId).length == 0);
       }
                   
    </script>         
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrap">               
        <h1>The Periodic Refresh Pattern</h1>   
            <p>
            All the action as it happens from todays football games<br />                    
            by your man in the stand Steve Mills
            </p>                     
        <hr />            
        <div id="main-content">                       
            <div id="Paused">Paused due to inactivity.</div>             
            <div id="Events">                                         
                <div id="LoadingBlock" class="LoadingBlock"></div>
                <div id="Event"></div>                        
            </div>
            <div id="Loading" class="Loading">Updating... <img src='Content/ajax-loader.gif' /></div>            
        </div>         
    </div>            
    </form>
</body>
</html>
