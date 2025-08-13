# SpeechToTextIntegration Demo

This project demonstrates the integration of the Telerik UI for Blazor `SpeechToTextButton` component with a transcription model, such as OpenAI's `whisper-1`. It provides a simple Blazor UI for recording audio and transcribing speech to text, showcasing how to connect the UI component to a backend speech-to-text service.

## Main Purpose
- **Showcase**: Illustrates how to use the Telerik `SpeechToTextButton` in a Blazor application.
- **Integration**: Demonstrates sending recorded audio to a transcription model (e.g., OpenAI Whisper) and displaying the transcribed text in the UI.
- **Extensibility**: Serves as a starting point for integrating other speech-to-text models or services.

## Configuration Notes
- **Model Registration**: The setup for registering a transcription model (such as OpenAI Whisper or others) may vary. Refer to the specific model's documentation for registration and authentication steps.
- **Audio Recording**: The requirements for the recorded audio (file size, type, encoding, etc.) depend on the chosen transcription model. Ensure that the audio format produced by the UI matches the model's expected input.
- **Customization**: You may need to adjust the audio recording logic or backend integration to support different models or to optimize for accuracy and performance.

---
For more details, see the source code and comments in the `Home.razor` component.
