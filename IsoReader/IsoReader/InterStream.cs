namespace IsoReader;

public record ReadResult (byte[] Bytes, int BytesRead);
public delegate byte[] ReadDelegate(int offset, int count);
public delegate void SetPosition(long position);
public delegate long StreamLength();

public class InterStream(ReadDelegate read, StreamLength streamLength, SetPosition setPosition) : Stream
{
    private long _position;
    public override void Flush()
    {
        throw new NotImplementedException();
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        var result = read(offset, count);
        Position += result.Length;
        
        Array.Copy(result, 0, buffer, offset, count);
        
        return result.Length;
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        throw new NotImplementedException();
    }

    public override void SetLength(long value)
    {
        throw new NotImplementedException();
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        throw new NotImplementedException();
    }

    public override bool CanRead => true;
    public override bool CanSeek => false;
    public override bool CanWrite => false;
    public override long Length => streamLength();

    public override long Position
    {
        get => _position;
        set
        {
            _position = value;
            setPosition(value);
        }
    }
}