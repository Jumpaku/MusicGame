public class NotesData {
	public enum NotesPosition {
		L, LC, C, RC, R,
	}
	public enum NotesType {
		Tap, Long, Flick, Slide
	}
    public float Time { get; private set; }
    public int ChannelId { get; private set; }
    public NotesType Type { get; private set; }
    public NotesPosition Goal { get; private set; }
    public NotesPosition Start { get; private set; }
	public NotesData(float time, int channelId, NotesType type, NotesPosition goal, NotesPosition start) {
		Time = time;
		ChannelId = channelId;
		Type = type;
		Goal = goal;
		Start = start;
	}
}
