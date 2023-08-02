using System;
using System.Collections.ObjectModel;

namespace SaamApp.Maui.Client.Onboarding
{
    public class OnboardingViewModel
    {
        #region Properties
        public ObservableCollection<OnboardingModel> OnboardSteps { get; set; } = new ObservableCollection<OnboardingModel>();
        #endregion

        public OnboardingViewModel()
        {
            OnboardSteps.Add(new OnboardingModel
            {
                OnboardingTitle = "Resuelve tus problemas",
                OnboardingDescription = "Encuentra soluciones a tus problemas cotidianos a través de asesorías brindadas por profesionales.",
                OnboardingImage = "vectorburbuja1"
            });

            OnboardSteps.Add(new OnboardingModel
            {
                OnboardingTitle = "Asesorías profesionales",
                OnboardingDescription = "Chatea o llama a un asesor profesional donde quiera que estés, desde la comodidad de tu celular.",
                OnboardingImage = "vectorburbuja2"
            });

            OnboardSteps.Add(new OnboardingModel
            {
                OnboardingTitle = "Tu información es privada",
                OnboardingDescription = "Queremos proteger tus datos e información. Es por eso que mantenemos tu identidad anónima.",
                OnboardingImage = "vectorburbuja4"
            });

            OnboardSteps.Add(new OnboardingModel
            {
                OnboardingTitle = "Recarga saldo",
                OnboardingDescription = "El saldo te da tiempo para asesorías. Recarga el saldo que desees antes de iniciar una asesoría.",
                OnboardingImage = "vectorburbuja3"
            });

            OnboardSteps.Add(new OnboardingModel
            {
                OnboardingTitle = "¿Estás listo?",
                OnboardingDescription = "¡Ingresa e inicia una asesoría hoy!",
                OnboardingImage = "vectorburbuja1"
            });

            for (int i = 0; i < OnboardSteps.Count; i++)
            {
                var dataItem = OnboardSteps[i];
                dataItem.IsLastItem = (i == OnboardSteps.Count - 1);

            }
        }

    }
}

