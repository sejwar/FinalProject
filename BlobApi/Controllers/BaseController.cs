using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlobApi.Entities;
using BlobApi.Services;
using BlobApi.Services.Interfaces;
using BlobApi.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BlobApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    public class BaseController : ControllerBase
    {
        private readonly IBlobService _blobService;

        public BaseController(IBlobService blobService)
        {
            _blobService = blobService;
        }

        /// <summary>
        /// Get the Blob for an id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetBlob")]
        public IActionResult GetBlob(int id)
        {
            try
            {
                if (id < 0)
                    return BadRequest(new { error = "The input was not valid." });

                BlobVM _blob = _blobService.GetBlob(id);

                if (_blob == null)
                    return NotFound(new { error = "Object not found." });

                return Ok(_blob);
                

            }

            catch(Exception ex)
            {
                return BadRequest(new { error = ex.ToString() });
            }
        }

        /// <summary>
        /// Gel all blobs
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetBlobs")]
        public IActionResult GetBlobs()
        {
            try
            {
                List<BlobVM> _blobs = new List<BlobVM>();
                _blobs = _blobService.GetBlobs();
                return Ok(_blobs);
            }

            catch (Exception ex)
            {
                return BadRequest(new { error = ex.ToString() });
            }
        }

        /// <summary>
        /// Save the new Blob
        /// </summary>
        /// <param name="blob"></param>
        /// <returns></returns>
        [HttpPost("SaveBlob")]
        public IActionResult SaveBlob([FromBody]Blob blob)
        {
            try
            {
                if (blob == null)
                    return BadRequest(new { error = "Input object is not valid." });

                _blobService.SaveBlob(blob);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.ToString() });
            }
        }

        /// <summary>
        /// Delete a blob
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        [Route("DeleteBlob/{id}")]
        [HttpDelete()]
        public IActionResult DeleteBlob(int id)
        {
            try
            {
                if (id < 0)
                    return BadRequest(new { error = "The input was not valid." });
                bool _isDeleted = _blobService.DeleteBlob(id);
                if (_isDeleted)
                    return Ok();
                else
                    return NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest(new { error = ex.ToString() });
            }
        }

        /// <summary>
        /// Update a blob
        /// </summary>
        /// <param name="id"></param>
        /// <param name="blob"></param>
        /// <returns></returns>
        [HttpPut("UpdateBlob/{id}")]
        public IActionResult UpdateBlob(int id,[FromBody]Blob blob)
        {
            try
            {
                if (id <= 0)
                    return BadRequest(new { error = "Input id is not valid." });

                if (blob == null)
                    return BadRequest(new { error = "Input object is not valid." });

                bool _isUpdated=_blobService.UpdateBlob(id,blob);

                if (_isUpdated)
                    return NoContent();
                else
                    return NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.ToString() });
            }
        }
    }
}
