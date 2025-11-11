using Microsoft.AspNetCore.Mvc;
using Notes.Application.Services;
using Notes.Web.ViewModels;

namespace Notes.Web.Controllers
{
    public class NotesController : Controller
    {
        private readonly INoteService _service;
        private readonly ILogger<NotesController> _logger;
        public NotesController(INoteService service, ILogger<NotesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var notes = await _service.GetNotesAsync();
            var vm = notes.Select(n => new NoteListVm { Id = n.Id, Title = n.Title, Excerpt = n.Content?.Length > 200 ? n.Content[..200] + "…" : n.Content, Priority = n.Priority });
            return View(vm);
        }

    public IActionResult Create() => View(new NoteEditVm());

        [HttpPost]
        public async Task<IActionResult> Create(NoteEditVm vm)
        {
            if (!ModelState.IsValid) return View(vm);
                var dto = await _service.CreateNoteAsync(new CreateNoteRequest(vm.Title, vm.Content, vm.IsPublic, vm.Priority));
               return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var note = await _service.GetNoteAsync(id);
            if (note == null) return NotFound();
            var vm = new NoteEditVm { Id = note.Id, Title = note.Title, Content = note.Content, IsPublic = note.IsPublic, Priority = note.Priority };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NoteEditVm vm)
        {
            if (!ModelState.IsValid) return View(vm);
                var success = await _service.UpdateNoteAsync(new UpdateNoteRequest(vm.Id!.Value, vm.Title, vm.Content, vm.IsPublic, vm.Priority));
            if (!success) return NotFound();
               return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteNoteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
