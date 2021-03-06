import 'package:event_bus/event_bus.dart';
import 'package:injectable/injectable.dart';

@singleton
class EventService {
  EventBus _eventBus;

  EventService() {
    _eventBus = new EventBus();
  }

  Stream<T> on<T>() {
    return _eventBus.on();
  }

  void fire(event) {
    _eventBus.fire(event);
  }

  void destroy() {
    _eventBus.destroy();
  }
}
