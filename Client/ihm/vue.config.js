module.exports = {
    devServer: {
      proxy: {
        '/api': {
          target: 'http://localhost:5104/', // Replace with your backend server URL
          changeOrigin: true,
          pathRewrite: { '^/api': '' },
        },
      },
    },
  };