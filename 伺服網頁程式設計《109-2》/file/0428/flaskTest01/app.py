from flask import Flask, render_template
app = Flask(__name__)

posts = [
    {
        'author': 'Jane Doe',
        'title': 'Blog Post 1',
        'content': 'Second post content',
        'date_posted': 'April 21, 2018'
    },
     {
        'author': 'Jane Doe',
        'title': 'Blog Post 2',
        'content': 'Second post content',
        'date_posted': 'April 21, 2018'
    }
]

@app.route("/")
@app.route("/home")
def home():
    return render_template('home.html',posts=posts)

@app.route("/about")
def about():
    return render_template('about.html')

if __name__ == '__main__':
    app.run(debug=True)
