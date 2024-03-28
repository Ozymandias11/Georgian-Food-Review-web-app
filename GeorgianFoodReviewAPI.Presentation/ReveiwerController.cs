﻿using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.DtosForPost;
using Shared.DataTransferObjects.DtosForPut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgianFoodReviewAPI.Presentation
{
    [Route("api/reviewers")]
    [ApiController]
    public class ReveiwerController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ReveiwerController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviewers()
        {
            var reviewers = await _service.ReviewerService.GetAllReviewersAsync(trackChanges:false);
            return Ok(reviewers);
        }

        [HttpGet("{id:guid}", Name = "GetReviewerById")]
        public async Task<IActionResult> GetReviewers(Guid id) 
        {
            var reviewer = await _service.ReviewerService.GetReviewerAsync(id, trackChanges:false);
            return Ok(reviewer);    
        }

        [HttpGet("country/{countryId:Guid}")]
        public async Task<IActionResult> GetReviewersOfCountry(Guid countryId)
        {
            var reviewers = await _service.ReviewerService.GetReviewersOfCountryAsync(countryId, trackChanges:false);
            return Ok(reviewers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReviewerForCountry(Guid countryId, [FromBody] ReviewerForCreationDto reviewer)
        {
            if (reviewer is null)
                return BadRequest("ReviewerForCreationDto is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createdReviewer = await _service.ReviewerService.CreateReviewerForCountryAsync(countryId, reviewer, 
                trackChanges:false);

            return CreatedAtRoute("GetReviewerById", new { countryId, id = createdReviewer.id }, createdReviewer);

        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteReviewer(Guid id)
        {
            await _service.ReviewerService.DeleteReviewerAsync(id, trackChanges:false);
            return NoContent();
        }

        [HttpPut("country/{countryId:Guid}/reviewer/{reviewerId:Guid}")]
        public async Task<IActionResult> UpdateReviewerForCountry(Guid countryId, Guid reviewerId, [FromBody] 
                                                         ReviewerForUpdateDto reviewer)
        {
            if (reviewer is null)
                return BadRequest("ReviewerForUpdateDto is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _service.ReviewerService.UpdateReviewerForCountryAsync(countryId, reviewerId, reviewer, countryTrackChanges: false,
                                                              reviewerTrackChanges: true);
            return NoContent();
        }
        [HttpPatch("country/{countryId:Guid}/reviewer/{reviwerId:Guid}/partial")]
        public async Task<IActionResult> partiallyUpdateReviewerForCountry(Guid countryId, Guid reviwerId,
            [FromBody] JsonPatchDocument<ReviewerForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("PathDoc is null");

            var result = await _service.ReviewerService.GetReviewerForPatchAsync(countryId, reviwerId,
                countryTrackChanges: false, reviewerTrackChanges: true);

            patchDoc.ApplyTo(result.reviewerToPatch);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            TryValidateModel(result.reviewerToPatch);

            await _service.ReviewerService.SaveChangesForPatchAsync(result.reviewerToPatch,
                result.reviwerEntity);

            return NoContent();

        }
    }
}
