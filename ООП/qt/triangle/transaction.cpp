            richTextBoxChat.Clear();
foreach (var message in bot.GetHistory())
{
    string timestamp = message.Timestamp.ToString("HH:mm:ss");
    AppendColoredText(string.Format("[{0}] {1}: {2}\n", timestamp, message.Author, message.Text), message.Author);
}
