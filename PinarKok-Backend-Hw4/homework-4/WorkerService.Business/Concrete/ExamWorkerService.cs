using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WorkerService.DataAccess.Concrete.Context;

namespace WorkerService.Business.Concrete
{
    public class ExamWorkerService : BackgroundService
    {
        private ILogger<ExamWorkerService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private OnlineExaminationSystemContext _dbContext;

        public ExamWorkerService(ILogger<ExamWorkerService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            var scope = _scopeFactory.CreateScope();
            _dbContext = scope.ServiceProvider.GetRequiredService<OnlineExaminationSystemContext>();
            await base.StartAsync(cancellationToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken);
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_dbContext == null)
                {
                    var scope = _scopeFactory.CreateScope();
                    _dbContext = scope.ServiceProvider.GetRequiredService<OnlineExaminationSystemContext>();
                }

                var finishedExams = await _dbContext.Exams
                                                   .Where(exam => !exam.IsFinished).ToListAsync();

                foreach (var exam in finishedExams)
                {
                    // bir şeyler yap!
                    exam.IsFinished = true;
                }

                if (_dbContext.ChangeTracker.HasChanges())
                {
                    await _dbContext.SaveChangesAsync();
                }

                _logger.LogInformation("Worker Service is running!");

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
