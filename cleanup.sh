find . -type d -name "bin" -exec rm -rf {} +
find . -type d -name "obj" -exec rm -rf {} +

# Remove macOS system files
find . -type f -name ".DS_Store" -delete
find . -type f -name "._*" -delete

echo "Cleanup completed!"
