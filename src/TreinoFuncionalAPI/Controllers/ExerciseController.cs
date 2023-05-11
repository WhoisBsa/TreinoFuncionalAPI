using Amazon.DynamoDBv2.DataModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TreinoFuncionalAPI.Data.DTOs.Exercise;
using TreinoFuncionalAPI.Models;
using TreinoFuncionalAPI.Services;

namespace TreinoFuncionalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : ControllerBase
    {
        private ExerciseService _exerciseService;

        public ExerciseController(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        /// <summary>
        /// Get exercises list.
        /// </summary>
        /// <response code="200">Obtained successful.</response>
        /// <response code="400">An error occurred.</response>
        [HttpGet]
        public async Task<IActionResult> Get() {
            try
            {
                var exercisesDTO = await _exerciseService.GetAll();

                return Ok(exercisesDTO);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Get the exercise informed.
        /// </summary>
        /// <param name="id">Id of the exercise</param>
        /// <response code="200">Obtained successful.</response>
        /// <response code="404">Exercise not found.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var exerciseDTO = await _exerciseService.GetById(id);

                return Ok(exerciseDTO);
            } catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Create a new exercise
        /// </summary>
        /// <param name="exerciseDTO">The new exercise</param>
        /// <response code="200">Successfully created.</response>
        /// <response code="400">Failure on create exercise.</response>
        [HttpPost]
        public async Task<IActionResult> Create(CreateExerciseDTO exerciseDTO)
        {
            try
            {
                var exercise = await _exerciseService.Create(exerciseDTO);

                return CreatedAtAction(nameof(GetById), new { id = exercise.Id }, exercise);
            } catch(Exception ex) { 
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Alter the exercise informed.
        /// </summary>
        /// <param name="id">Exercise id</param>
        /// <param name="exerciseDTO">The updated exercise</param>
        /// <response code="200">Update successful.</response>
        /// <response code="400">Exercise not found.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateExerciseDTO exerciseDTO)
        {
            try
            {
                await _exerciseService.Update(id, exerciseDTO);

                return NoContent(); 
            } catch(Exception ex) {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Delete an exercise
        /// </summary>
        /// <param name="id">Exercise id</param>
        /// <response code="200">Deletes an exercise.</response>
        /// <response code="404">Exercise not found.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _exerciseService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
