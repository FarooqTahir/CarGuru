var apiKey = "46873904";
var session;


function connect(sessionId, token) {
    OT.on("exception", exceptionHandler);

    // Un-comment the following to set automatic logging:
    OT.setLogLevel(OT.DEBUG);

    if (!(OT.checkSystemRequirements())) {
        alertR("You don't have the minimum requirements to run this application.");
    } else {

        session = OT.initSession(sessionId);	// Initialize session
        session.connect(apiKey, token);
        // Add event listeners to the session
        session.on('sessionConnected', sessionConnectedHandler);
        session.on('sessionDisconnected', sessionDisconnectedHandler);
        session.on('connectionCreated', connectionCreatedHandler);
        session.on('connectionDestroyed', connectionDestroyedHandler);
        //session.on('streamCreated', streamCreatedHandler);
        // session.on('streamDestroyed', streamDestroyedHandler);
        session.on("signal", signalEventHandler);
    }
}

function disconnect() {
    stopPublishing();
    session.disconnect();

    hide('disconnectLink');

}

function stopPublishing() {
    if (publisher) {
        session.unpublish(publisher);
    }
    publisher = null;


}


function sessionConnectedHandler(event) {

    //startPublishing();
    // show('disconnectLink');
    //hide('connectLink');
}
function formatAMPM(date) {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var ampm = hours >= 12 ? 'PM' : 'AM';
    hours = hours % 12;
    hours = hours ? hours : 12; // the hour '0' should be '12'
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + ' ' + ampm;
    return strTime;
}
function connectionDestroyedHandler(event) {
    //$('.messages__item[loginid=43]').find('span').attr('class');
    //$('.message-content-status').html('offline');

    var userInfo = event.connection.data;
    if (userInfo != null) {
        updateUserStatus(userInfo, false, null);
        if ($("#openTokModal").data('bs.modal') && $("#openTokModal").data('bs.modal').isShown) {
            if ($('.messages__item[loginid=' + userInfo + ']').hasClass('active')) {
                if ($('.messages__item[loginid=' + userInfo + ']').find('span').hasClass('online')) {
                    $('.messages__item[loginid=' + userInfo + ']').find('span').removeClass('online');
                    $('.messages__item[loginid=' + userInfo + ']').find('span').addClass('offline');
                    $('.message-content-status').html('offline');
                    //$('.reminder-btn').show();
                }

            } else {
                if ($('.messages__item[loginid=' + userInfo + ']').find('span').hasClass('online')) {
                    $('.messages__item[loginid=' + userInfo + ']').find('span').removeClass('online');
                    $('.messages__item[loginid=' + userInfo + ']').find('span').addClass('offline');
                }
            }
        }
    }
}


function connectionCreatedHandler(event) {
    //$('.messages__item[loginid=43]').find('span').attr('class');
    //$('.message-content-status').html('online');
    var userInfo = event.connection.data;
    //if (userInfo != null) {
    //    updateUserStatus(userInfo, true, event.connection.connectionId);
    //    if ($("#openTokModal").data('bs.modal') && $("#openTokModal").data('bs.modal').isShown) {
    //        if ($('.messages__item[loginid=' + userInfo + ']').hasClass('active')) {
    //            if ($('.messages__item[loginid=' + userInfo + ']').find('span').hasClass('offline')) {
    //                $('.messages__item[loginid=' + userInfo + ']').find('span').removeClass('offline');
    //                $('.messages__item[loginid=' + userInfo + ']').find('span').addClass('online');
    //                $('.message-content-status').html('online');
    //                //$('.reminder-btn').hide();
    //            }

    //        } else {
    //            if ($('.messages__item[loginid=' + userInfo + ']').find('span').hasClass('offline')) {
    //                $('.messages__item[loginid=' + userInfo + ']').find('span').removeClass('offline');
    //                $('.messages__item[loginid=' + userInfo + ']').find('span').addClass('online');
    //            }
    //        }
    //    }
    //    if (userInfo == loginId) {
    //        getchatList(loginId);
    //    }
    //}
}
function insertChat(type, message) {
    if (message != null && message != "") {
        if (type == 'outgoing') {
            debugger
            var myImage = $("#my-chat-profile-image").val() || "";
            var image = "";
            var errorImage = "/dist/img/user3-128x128.jpg";
            if (myImage != "") {
                image = myImage;
            }
            var name = $("#my-chat-name").val() || "";
            var currDate = moment().format('DD MMMM hh:mm A');
            var text = '<div class="direct-chat-msg right">'+
                '<div class="direct-chat-infos clearfix">'+
                    '<span class="direct-chat-name float-right">'+name+'</span>'+
                '<span class="direct-chat-timestamp float-left">' + currDate+'</span>'+
                '</div >' +
                '<img class="direct-chat-img" src="' + image + '" onerror="this.onerror=null;this.src=' + errorImage + ';" alt="message user image">' +

                    '<div class="direct-chat-text">'+
                        message
            +'</div>'+
        '</div>';
            $(".direct-chat-messages").append(text);
        
        } else {
            var name = $("#my-chat-name").val() || "";
            var currDate = moment().format('DD MMMM hh:mm A');
            var text = '<div class="direct-chat-msg">' +
                '<div class="direct-chat-infos clearfix">' +
                '<span class="direct-chat-name float-left">' + name + '</span>' +
                '<span class="direct-chat-timestamp float-right">' + currDate + '</span>' +
                '</div >' +
                '<img class="direct-chat-img" src="/dist/img/user1-128x128.jpg" alt="message user image">' +

                '<div class="direct-chat-text">' +
                message
                + '</div>' +
                '</div>';
            $(".direct-chat-messages").append(text);
        }
    }
}
function SendMessageSignal(message, myuserId, contactuserId) {
    var customObj = { Message: message, FromUserId: myuserId, ToUserId: contactuserId };
    var customJson = JSON.stringify(customObj);
    //var customJson = '{"msg":"' + ele.value + '","loginId":' + loginId + ',"chatId":"' + chatId + '"}';
    session.signal({
        //type: 'msg',
        data: customJson
    }, function (error) {
        if (error) {
            console.log('Error sending signal:', error.name, error.message);
        } else {
            // msgTxt.value = '';
        }
    });
}
function SrollMessages() {
    setTimeout(
        function () {
            var scrollHeightControl = $(".direct-chat-messages")[0];
            if (scrollHeightControl != undefined) {
                $(".direct-chat-messages").stop().animate({ scrollTop: $(".direct-chat-messages")[0].scrollHeight }, 500, 'swing', function () { });
            }
        }, 10);
}
function ClearMessageBox() {
    $("#chat-message").val("");
}
$(document).ready(function () {
    $(document).on('keyup', "#chat-message", function (e) {
        
        if (e.key === 'Enter' || e.keyCode === 13) {
            SendMessage();
        }
    });
});
var messageSound = document.getElementById("MessageAudio");

function playAudio() {
    messageSound.play();
}

function pauseAudio() {
    messageSound.pause();
} 
function sessionDisconnectedHandler(event) {
    // This signals that the user was disconnected from the Session. Any subscribers and publishers
    // will automatically be removed. This default behaviour can be prevented using event.preventDefault()

    var userInfo = event.connection.data;
    if (userInfo != null) {
        updateUserStatus(userInfo, false, null);
    }
    session.off('sessionConnected', sessionConnectedHandler);
    session.off('streamCreated', streamCreatedHandler);
    session.off('streamDestroyed', streamDestroyedHandler);
    session.off('connectionCreated', connectionCreatedHandler);
    session.off("signal", signalEventHandler);
    OT.off("exception", exceptionHandler);
    session.off('sessionDisconnected', sessionDisconnectedHandler);
    publisher = null;

}
function updateUserStatus(loginId, status, currentConnectionId) {
    //$.ajax({
    //    type: "GET",
    //    url: '../Login/UpdateLoginStatus',
    //    data: { loginId: loginId, status: status, connectionId: currentConnectionId },
    //    success: function (data) {
    //    },
    //    error: function (res) {
    //        AjaxFailure(res);
    //    }
    //});
}
function signalEventHandler(event) {


    if (event.type == "signal:AppointmentRoomStatus") {

        var msgObj = JSON.parse(event.data);
        if (msgObj.recieverLoginId == loginId) {
            alertG(msgObj.Message);
        }
    }
    else if (event.type == "signal:begincall") {

        var msgObj = JSON.parse(event.data);
        if (msgObj.recieverLoginId == loginId) {
            $('.callerTxt').html('');
            $('#callTone')[0].pause();
            $('#callTone')[0].currentTime = 0;
            $('#callerdialogbox').modal('hide');
        }
        var returnedData = $.grep(chatList, function (element, index) {
            return element.ChatId == msgObj.chatId;
        });
        if (returnedData.length > 0 || loginId == msgObj.recieverLoginId) {
            if (loginId != msgObj.loginId) {
                // $('.call-btn').hide();
                $('#callDialog').modal('show');
                $('.callerTxt').html('Incoming call from ' + msgObj.msg);
                $('#callTone')[0].play();
            }
        }
        //***************************Call Begin*********************************//            

        //***************************Accept Call*************************************//
        document.getElementById('callAcceptButton').onclick = function () {
            $('#callDialog').modal('hide');
            $('.callerTxt').html('');
            $('#callTone')[0].pause();
            $('#callTone')[0].currentTime = 0;
            var username = '';
            username = $('.user-name').attr('username');
            var callStatus = 'yes';
            var recieverLoginId = msgObj.loginId;
            var customObj = { msg: username, loginId: loginId, chatId: msgObj.chatId, status: 'yes', connectionId: event.from.connectionId, callType: msgObj.callType, recieverLoginId: msgObj.loginId };
            var customJson = JSON.stringify(customObj);
            //  var customJson = '{"msg":"' + username + '","loginId":' + loginId + ',"chatId":' + msgObj.chatId + ',"status":"yes"' + ',"connectionId":"' + event.from.connectionId + '"}';
            //addStream(_streams[_streamId]);
            CallLogs(msgObj.chatId, msgObj.loginId, msgObj.callType);
            session.signal({
                type: "acceptcall",
                // to: event.from.connectionId,
                data: customJson
            },
                function (error) {
                    if (error) { console.log("signal error: " + error.reason); }
                    else { console.log("signal sent"); }
                }
            );
            //window.open('../Chat/VideoChat?chatId=' + msgObj.chatId,
            //             'newwindow',
            //             'width=800,height=600');
            //var videoLink = '../Chat/VideoChat?chatId=' + msgObj.chatId;
            //$('.video-open-link').attr('href', videoLink);
            //$('.video-open-link').click();
            //window.location.href

            //$('.video-open-link').target = "_blank";
            //var url = '../Chat/VideoChat?chatId=' + msgObj.chatId;
            //$('.video-open-link').attr("href", url);
            //window.open($('.video-open-link').attr("href"));

            //setTimeout(function () {
            //    window.location.href = '../Chat/VideoChat?chatId=' + msgObj.chatId + '&chatType=' + msgObj.callType + '&CallLogDetailsId=' + CallLogDetailsId; // Imp
            //}, 3000);


            //var win = window.open($('.video-open-link').attr("href")); //window.open('../Chat/VideoChat?chatId=' + msgObj.chatId, '_blank');
            //if (win) {
            //    //Browser has allowed it to be opened
            //    win.focus();
            //} else {
            //    //Browser has blocked it
            //    alert('Please allow popups for this website');
            //}

        }

        //***************************Accept Call*************************************//

        //***************************Reject Call*************************************//
        document.getElementById('callRejectButton').onclick = function () {
            // $('.call-btn').show();
            // document.getElementById('acceptCallBox').style.display = 'none';
            // document.getElementById('acceptCallLabel').innerHTML = '';
            $('#callDialog').modal('hide');
            $('.callerTxt').html('');
            $('#callTone')[0].pause();
            $('#callTone')[0].currentTime = 0;
            //$('.callerTxt').html('');
            //$('#callTone')[0].pause();
            //$('#callTone')[0].currentTime = 0;
            var username = '';
            username = $('.user-name').attr('username');
            var callStatus = 'no';
            var recieverLoginId = msgObj.loginId;
            var customObj = { msg: username, loginId: loginId, chatId: msgObj.chatId, status: 'no', connectionId: event.from.connectionId, callType: msgObj.callType, recieverLoginId: msgObj.loginId };
            var customJson = JSON.stringify(customObj);
            //var customJson = '{"msg":"' + username + '","loginId":' + loginId + ',"chatId":' + msgObj.chatId + ',"status":"no"}';
            session.signal({
                type: "acceptcall",
                //to: event.from.connectionId,
                data: customJson
            },
                function (error) {
                    if (error) { console.log("signal error: " + error.reason); }
                    else { console.log("signal sent"); }
                }
            );
        }
        //***************************Reject Call*************************************//
        //***************************Call Begin*********************************//
    }
    else if (event.type == "signal:acceptcall") {

        //console.log(event);
        //var msgObj = JSON.parse(event.data);
        //var returnedData = $.grep(chatList, function (element, index) {
        //    return element.ChatId == msgObj.chatId;
        //});
        //if (returnedData.length > 0 || loginId == msgObj.recieverLoginId) {

        //    if (msgObj.status == "yes") {
        //        if ($("#callerdialogbox").data('bs.modal').isShown) {
        //            window.location.href = '../Chat/VideoChat?chatId=' + msgObj.chatId + '&chatType=' + msgObj.callType + '&CallLogDetailsId=' + CallLogDetailsId; // Imp
        //        }
        //        $('#callerdialogbox').modal('hide');
        //        $('#callDialog').modal('hide');
        //        $('.callerTxt').html('');
        //        $('#callTone')[0].pause();
        //        $('#callTone')[0].currentTime = 0;
        //    } else {
        //        if ($("#callerdialogbox").data('bs.modal').isShown) {
        //            alertR('Call rejected by ' + msgObj.msg);
        //        }
        //        $('#callDialog').modal('hide');
        //        $('.callerTxt').html('');
        //        $('#callTone')[0].pause();
        //        $('#callTone')[0].currentTime = 0;
        //        $('#callerdialogbox').modal('hide');
        //    }
        //}
    }

    else if (event.type == "signal:cancelcall") {
        //var msgObj = JSON.parse(event.data);
        //var returnedData = $.grep(chatList, function (element, index) {
        //    return element.ChatId == msgObj.chatId;
        //});
        //if (returnedData.length > 0) {
        //    if (loginId != msgObj.loginId) {
        //        //$('.call-btn').show();
        //        $('#callDialog').modal('hide');
        //        $('.callerTxt').html('');
        //        $('#callTone')[0].pause();
        //        $('#callTone')[0].currentTime = 0;
        //    }
        //}

    }
    else if (event.type == 'signal') {
        
        var msgObj = JSON.parse(event.data);
        var LoginId = $("#my-login-id").val() || 0;
        if (LoginId == msgObj.ToUserId) {
            playAudio();
            var OtherUser = $("#contact-chat-user-id").val() || 0;
            if (OtherUser > 0) {
                if (OtherUser == msgObj.FromUserId) {
                    //$('.OpenChat').click();
                    insertChat('incoming', msgObj.Message)
                    SrollMessages();
                } else {
                    var count = $(".message-count").text() || 0;
                    count = parseInt(count);
                    count++;
                    $(".message-count").text(count);
                }
                
            } else {
                var count = $(".message-count").text() || 0;
                count = parseInt(count);
                count++;
                $(".message-count").text(count);
            }
            
        }
        //var msgObj = event.data;
        //var returnedData = $.grep(chatList, function (element, index) {
        //    return element.ChatId == msgObj.chatId;
        //});
        //if (returnedData.length > 0) {

        //    if ($("#openTokModal").data('bs.modal') && $("#openTokModal").data('bs.modal').isShown) {
        //        if ($('.chatUser[chatid=' + msgObj.chatId + ']').hasClass('active')) {
        //            var msg = '<p>' + msgObj.msg + '</p>';
        //            //$('.message-section').append(msg);
        //            if (loginId != msgObj.loginId) {
        //                var className = loginId == msgObj.loginId ? 'outgoing' : 'incoming';
        //                if (msgObj.FileType == "message") {
        //                    insertChat(className, msgObj.msg, 0, 'message');
        //                } else {
        //                    insertChat(className, msgObj.FileName, 0, 'attachment');
        //                }

        //                //insertChat('outgoing' , msgObj.msg, 0);
        //                if (className == 'incoming') {
        //                    $('#msgTone')[0].play();
        //                    setTimeout(function () {
        //                        $('#msgTone')[0].pause();
        //                        $('#msgTone')[0].currentTime = 0;
        //                        // Do something after 1 second
        //                    }, 1000);
        //                }
        //            }
        //        } else {
        //            if (loginId != msgObj.loginId) {
        //                //$('.chatUser[chatid=' + msgObj.chatId + ']').addClass('unread');
        //                //newmessages

        //                var countMessages = 0;
        //                countMessages = $('.newmessages[chatid=' + msgObj.chatId + ']').text();
        //                if (countMessages != '') {
        //                    countMessages = parseInt(countMessages);
        //                    countMessages++;
        //                    $('.newmessages[chatid=' + msgObj.chatId + ']').text(countMessages);
        //                    $('.newmessages[chatid=' + msgObj.chatId + ']').show();
        //                } else {
        //                    $('.newmessages[chatid=' + msgObj.chatId + ']').text('1');
        //                    $('.newmessages[chatid=' + msgObj.chatId + ']').show();
        //                }
        //                $('#msgTone')[0].play();
        //                setTimeout(function () {
        //                    $('#msgTone')[0].pause();
        //                    $('#msgTone')[0].currentTime = 0;
        //                    // Do something after 1 second
        //                }, 1000);
        //            }
        //        }
        //    } else {
        //        if (loginId != msgObj.loginId) {
        //            $('#msgTone')[0].play();
        //            setTimeout(function () {
        //                $('#msgTone')[0].pause();
        //                $('#msgTone')[0].currentTime = 0;
        //                //getChatModal(loginId);
        //                getUserNotification();
        //                alertG("New message received");
        //                //setTimeout(function () {
        //                //var className = loginId == msgObj.loginId ? 'outgoing' : 'incoming';
        //                //if (msgObj.FileType == "message") {
        //                //    //alert(msgObj.msg);
        //                //    insertChat(className, msgObj.msg, 0, 'message');
        //                //} else {
        //                //    insertChat(className, msgObj.FileName, 0, 'attachment');
        //                //    }
        //                //}, 1000);
        //            }, 1000);

        //            //alertG('new message recieved');
        //        }
        //    }

        //} else if (loginId == msgObj.recieverLoginId) {
        //    getchatList(loginId);
        //    $('#openTokModal').modal('hide');
        //    $('#msgTone')[0].play();
        //    setTimeout(function () {
        //        $('#msgTone')[0].pause();
        //        $('#msgTone')[0].currentTime = 0;
        //        getUserNotification();
        //        alertG("New message received");
        //        //getChatModal(loginId);
        //    }, 1000);
        //}
    }
    else if (event.type == 'signal:notification') {

        //var msgObj = JSON.parse(event.data);
        //if (loginId == msgObj.ProfileId && msgObj.ProfileType == 'doctor') {
        //    confirmNotification(msgObj.message);
        //    if (currProfileType.toLowerCase() == 'doctor') {
        //        setTimeout(function () {

        //            getDoctorNotification();
        //        }, 3000);
        //    }
        //} else if (loginId == msgObj.ProfileId && msgObj.ProfileType == 'doctorLogin') {
        //    confirmNotification(msgObj.message);
        //    if (currProfileType.toLowerCase() == 'doctor') {
        //        setTimeout(function () {

        //            getDoctorNotification();
        //        }, 3000);
        //    }
        //} else if (loginId == msgObj.ProfileId && msgObj.ProfileType == 'patientLogin') {
        //    confirmNotification(msgObj.message);
        //    if (currProfileType.toLowerCase() == 'patient') {
        //        setTimeout(function () {

        //            getPatientNotification();
        //        }, 3000);
        //    }
        //}
        //else if (loginId == msgObj.ProfileId && msgObj.ProfileType == 'patient') {
        //    confirmNotification(msgObj.message);
        //    if (currProfileType.toLowerCase() == 'patient') {
        //        setTimeout(function () {

        //            getPatientNotification();
        //        }, 3000);
        //    }
        //} else if (loginId == msgObj.ProfileId && msgObj.ProfileType == 'admin') {
        //    confirmNotification(msgObj.message);
        //    if (currProfileType.toLowerCase() == 'admin') {
        //        setTimeout(function () {

        //            getAdminNotification();
        //        }, 3000);

        //    }
        //}
    }

}
/*
If you un-comment the call to OT.setLogLevel(), above, OpenTok automatically displays exception event messages.
*/
function exceptionHandler(event) {
    //alertR("Sorry something went wrong, Kindly refresh the page");
    console.log("Exception: " + event.code + "::" + event.message);
    //$('#openTokModal').modal('hide');
}
function SendMessage() {
   
    var message = $("#chat-message").val();
    if (message != null && message != "") {
        var myuserId = $("#my-chat-user-id").val() || 0;
        var contactuserId = $("#contact-chat-user-id").val() || 0;
        if (myuserId > 0 && contactuserId > 0) {
            insertChat('outgoing', message);
            SendMessageSignal(message, myuserId, contactuserId);
            SrollMessages();
            ClearMessageBox();
            var chatModel = { FromUserId: myuserId, ToUserId: contactuserId, Message: message }
            $.ajax({
                type: "POST",
                url: '../Conversation/SendNewMessage',
                data: { model: chatModel },
                success: function (data) {
                   // moving the process above for making chat seam less and Fast.
                },
                error: function (res) {
                    AjaxFailure(res);
                }
            });
        }
    }
}