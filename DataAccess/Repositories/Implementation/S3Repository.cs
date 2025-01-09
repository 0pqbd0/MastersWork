using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementation;

public class S3Repository : IS3Repository
{
    private readonly IAmazonS3 _s3Client;
    private readonly string _bucketName;

    public S3Repository(IAmazonS3 s3Client, string bucketName)
    {
        _s3Client = s3Client;
        _bucketName = bucketName;
    }

    public async Task<string> UploadFileAsync(Stream fileStream, string fileName)
    {
        try
        {
            var putRequest = new PutObjectRequest
            {
                InputStream = fileStream,
                Key = fileName,
                BucketName = _bucketName,
                ContentType = "application/octet-stream"
            };

            var response = await _s3Client.PutObjectAsync(putRequest);

            var fileUrl = $"https://{_bucketName}.s3.storage.selcloud.ru/{fileName}";
            return fileUrl;
        }
        catch (Exception ex)
        {
            throw new Exception("Error uploading file to S3", ex);
        }
    }

    public async Task<Stream> GetFileAsync(string fileName)
    {
        try
        {
            var key = fileName.Split('/').Last();

            var getRequest = new GetObjectRequest
            {
                BucketName = _bucketName,
                Key = key
            };

            var response = await _s3Client.GetObjectAsync(getRequest);
            return response.ResponseStream;
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving file from S3", ex);
        }
    }
}
