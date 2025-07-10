from flask import Flask, request, render_template_string
import redis

app = Flask(__name__)
r = redis.Redis(host='redis', port=6379)

TEMPLATE = '''
<h1>Vote for your Hero!</h1>
<form method="POST">
  <button name="vote" value="ironman">Iron Man</button>
  <button name="vote" value="captainamerica">Captain America</button>
</form>
'''

@app.route('/', methods=['GET', 'POST'])
def vote():
    if request.method == 'POST':
        vote = request.form['vote']
        r.rpush('votes', vote)
    return render_template_string(TEMPLATE)

if __name__ == "__main__":
    app.run(host='0.0.0.0', port=8000)
