import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/players/colonized_stellar_object.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';
import 'stellar_object.dart';

@GuidConverter()
abstract class ColonizableStellarObject extends StellarObject {
  // @JsonKey()
  //SingleObjectSystem parentSystem;

  @JsonKey()
  Guid colonizedStellarObjectId;

  @JsonKey()
  ColonizedStellarObject colonizedStellarObject;

  ColonizableStellarObject();
}
