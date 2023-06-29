using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEscola.Api
{
    public class SettingsService : ISettingsService
    {
        private readonly Settings _settings;

        public SettingsService(IOptions<Settings> settings)
        {
            _settings = settings?.Value;
        }

        public Settings GetSettings()
        {
            return _settings;
        }
    }

    public interface ISettingsService
    {
        Settings GetSettings();
    }
}
