using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarGuru.Database.Dtos.ResponseDto;
using CarGuru.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarGuru.Controllers
{
    public class ConversationController : Controller
    {
        private readonly IConversationService _conversationService;
        private readonly ILookUpsService _lookUpsService;

        public ConversationController(IConversationService conversationService,ILookUpsService lookUpsService)
        {
            _conversationService = conversationService;
            _lookUpsService = lookUpsService;
        }
        [HttpPost]
        public async Task<IActionResult> GetChatMessages(long userId,long otherUserId)
        {
            var conversation = await _conversationService.GetChatMessagesById(userId,otherUserId);
             return PartialView("~/Views/Conversation/_ChatMessages.cshtml", conversation);
        }
        public IActionResult DeleteMessage(long conversationId)
        {
            var response = _conversationService.DeleteMessage(conversationId);
            return Json(response);
        }
        public IActionResult GetMessageById(long conversationId)
        {
            var response = _conversationService.GetSingleMessage(conversationId);
            return Json(response);
        }
        public async Task<IActionResult> SendNewMessage(ConversationDto model)
        {
            var response = await _conversationService.AddConversationMessage(model);
            // Push Notification
            return Json(response);
        }
        public IActionResult UpdateMessage(ConversationDto model)
        {
            var response = _conversationService.EditConversationMessage(model);
            return Json(response);
        }
        public IActionResult ReadMessage(long conversationId)
        {
            var response = _conversationService.ReadMessage(conversationId);
            return Json(response);
        }
        public IActionResult GetRoleByUserId(long userId)
        {
            var response = _lookUpsService.GetUserByUserId(userId);
            if(response.Data.RoleId> 0) return Json(response.Data.RoleId);
            return Json(0);
        }
        public IActionResult ReadConversationMessage(long userId,long otherUserId)
        {
            var response = _conversationService.ReadConversationMessage(userId,otherUserId);
            return Json(response);
        }
    }
}