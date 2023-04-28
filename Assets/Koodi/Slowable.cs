namespace Autopeli {
    public interface Slowable {
        public void slowDown();
        public void speedUp();
        public void addSpeed(int percent);
    }
}