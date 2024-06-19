using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // api/projects?query=net core
        [HttpGet]
        [Authorize(Roles = "Client, Freelancer")]
        public async Task<IActionResult> Get(string query)
        {
            var getAllProjectQuery = new GetAllProjectsQuery(query);

            var projects = await _mediator.Send(getAllProjectQuery);

            return Ok(projects);
        }

        // api/projects/3
        [HttpGet("{id}")]
        [Authorize(Roles = "Client, Freelancer")]
        public async Task<IActionResult> GetById(int id)
        {
            var getProjectByIdQuery = new GetProjectByIdQuery(id);

            var projects = await _mediator.Send(getProjectByIdQuery);

            if (projects == null)
            {
                return NotFound();
            }

            return Ok(projects);
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        { 

            //var id = _projectService.Create(inputModel);
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        // api/projects/2
        [HttpPut("{id}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        // api/project/3
        [HttpDelete("{id}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/1/comments POST
        [HttpPost("{id}/comments")]
        [Authorize(Roles = "Client, Freelancer")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            //_projectService.CreateComment(inputModel);
            await _mediator.Send(command);

            return NoContent();
        }
 

        // api/projects/1/start
        [HttpPut("{id}/start")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/1/finish
        [HttpPut("{id}/finish")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Finish(int id)
        {
            var command = new FinishProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
