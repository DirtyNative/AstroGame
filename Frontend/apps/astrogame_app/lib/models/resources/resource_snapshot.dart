import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/resources/stored_resource.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'resource_snapshot.g.dart';

@GuidConverter()
@JsonSerializable()
class ResourceSnapshot {
  Guid id;
  Guid stellarObjectId;
  DateTime snapshotTime;
  List<StoredResource> storedResources;

  ResourceSnapshot();

  factory ResourceSnapshot.fromJson(Map<String, dynamic> json) =>
      _$ResourceSnapshotFromJson(json);
  Map<String, dynamic> toJson() => _$ResourceSnapshotToJson(this);
}
